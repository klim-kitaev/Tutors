import { Component, OnInit } from '@angular/core';
import { CalendarView, CalendarEvent, DAYS_OF_WEEK, CalendarDateFormatter, CalendarEventTimesChangedEvent, CalendarMonthViewBeforeRenderEvent, CalendarEventAction } from 'angular-calendar';
import { Subject } from 'rxjs';
import { CustomDateFormatter } from './custom-date-formatter-provider';
import {
  isSameMonth,
  isSameDay,
  startOfMonth,
  endOfMonth,
  startOfWeek,
  endOfWeek,
  startOfDay,
  endOfDay,
  format,
  parse
} from 'date-fns';
import { LessonRepositoryService } from 'src/app/services/lesson-repository.service';
import { LessonRequest } from 'src/app/models/lesson/lessonRequest.model';
import { MatDialog } from '@angular/material';
import { AlertDialogComponent } from '../common/alert-dialog/alert-dialog.component';
import { lessonInfo } from 'src/app/models/lesson/lessonInfo.model';
import { LessonDialogComponent } from './lesson-dialog/lesson-dialog.component';
import { pupilInfo } from 'src/app/models/pupil/pupilInfo.model';
import { WeekDay } from 'calendar-utils';

const colors: any = {
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF'
  },
  grey: {
    primary: '#999',
    secondary: '#ddd'
  }
};

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
  providers: [
    {
      provide: CalendarDateFormatter,
      useClass: CustomDateFormatter
    }
  ]
})
export class CalendarComponent implements OnInit {

  constructor(private lessonRep: LessonRepositoryService, public dialog: MatDialog) {
  }

  ngOnInit() {
    this.fetchLessons();
  }

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  locale: string = 'ru';

  weekStartsOn: number = DAYS_OF_WEEK.MONDAY;

  events: CalendarEvent<lessonInfo>[] = [];

  refresh: Subject<any> = new Subject();


  fetchLessons() {

    console.log(this.viewDate);

    const getStart: any = {
      month: startOfMonth,
      week: startOfWeek,
      day: startOfDay
    }[this.view];

    const getEnd: any = {
      month: endOfMonth,
      week: endOfWeek,
      day: endOfDay
    }[this.view];

    const options: any = {
      month: {},
      week: { weekStartsOn: this.weekStartsOn },
      day: {}
    }[this.view];

    let request: LessonRequest = {
      startDate: format(getStart(this.viewDate, options), 'DD.MM.YYYY'),
      endDate: format(getEnd(this.viewDate, options), 'DD.MM.YYYY')
    }
    //console.log(startOfWeek(this.viewDate, {weekStartsOn: 1}));

    this.lessonRep.getLessons(request).subscribe(
      lessons => {
        this.events = lessons.map(p => this.convertLessonToEvent(p));
        console.log(this.events);
      },
      error => this.showAllert(error)
    );

  }

  showAllert(alert: string): void {
    console.log(alert);
    this.dialog.open(AlertDialogComponent, {
      data: alert, width: '250px'
    });
  }

  convertLessonToEvent(lessonInfo: lessonInfo): CalendarEvent<lessonInfo> {
    return {
      meta: lessonInfo,
      start: parse(lessonInfo.startDate),
      end: parse(lessonInfo.endDate),
      title: `${format(lessonInfo.startDate, "HH:mm")} - ${format(lessonInfo.endDate, "HH:mm")} ${lessonInfo.pupilName} `,
      color: parse(lessonInfo.startDate) < new Date() ? colors.grey : colors.blue
    }
  }

  /**
   * Выбор конкретного урока (для месячного календаря)
   */
  showMonthEvent(event: Event, dayEvent: CalendarEvent<lessonInfo>): void {
    let dialogRef = this.dialog.open(LessonDialogComponent, {
      data: {
        calendarEvent: dayEvent,
        initDate: dayEvent.start
      }, width: '350px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == 'updated') {
        this.fetchLessons();
      }
    });
    event.stopPropagation();
  }

  /**
   * Выбор конкретного урока
   */
  showEvent(dayEvent: CalendarEvent<lessonInfo>): void {
    let dialogRef = this.dialog.open(LessonDialogComponent, {
      data: {
        calendarEvent: dayEvent,
        initDate: dayEvent.start
      }, width: '350px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == 'updated') {
        this.fetchLessons();
      }
    });
  }

  /**
   * Уже прошедшие уроки помечяются специальным классом
   * @param startDate время события
   */
  setEventClass(startDate: Date) {
    return new Date() < startDate ? "" : "in-past";
  }

  dayClick(day: WeekDay) {
    let dialogRef = this.dialog.open(LessonDialogComponent, {
      data: {
        initDate: day.date
      }, width: '350px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == 'updated') {
        this.fetchLessons();
      }
    });
  }

  hourClick(date: Date) {
    let dialogRef = this.dialog.open(LessonDialogComponent, {
      data: {
        initDate: date
      }, width: '350px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == 'updated') {
        this.fetchLessons();
      }
    });
  }
  addLesson() {
    let dialogRef = this.dialog.open(LessonDialogComponent, {
      data: {}, width: '350px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == 'updated') {
        this.fetchLessons();
      }
    });
  }

}
