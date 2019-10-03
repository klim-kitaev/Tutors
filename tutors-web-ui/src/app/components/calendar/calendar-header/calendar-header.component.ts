import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-calendar-header',
  templateUrl: './calendar-header.component.html',
  styleUrls: ['./calendar-header.component.css']
})
export class CalendarHeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input() view: string;

  @Input() viewDate: Date;

  @Input() locale: string;

  @Input() weekStartsOn: number;

  @Output() viewChange: EventEmitter<string> = new EventEmitter();

  @Output() viewDateChange: EventEmitter<Date> = new EventEmitter();

  get nextLabel() {
    switch(this.view){
      case 'month':
        return 'Следующий месяц';
      case 'week':
        return 'Следующая неделя';
      case 'day':
        return 'Следующий день';
    }
    return '';
  };

  get prevLabel() {
    switch(this.view){
      case 'month':
        return 'Предыдущий месяц';
      case 'week':
        return 'Предыдущая неделя';
      case 'day':
        return 'Предыдущий день';
    }
    return '';
  };

}
