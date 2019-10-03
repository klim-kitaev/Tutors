import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CalendarEvent } from 'angular-calendar';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { changeLessonInfo } from 'src/app/models/lesson/changeLessonInfo.model';
import { lessonInfo } from 'src/app/models/lesson/lessonInfo.model';
import { PupilRepositoryService } from 'src/app/services/pupil-repository.service';
import { dict } from 'src/app/models/common/dict';
import { lessonsDurations } from 'src/app/models/common/global';
import {
  format,
  parse,
  addHours,
  addMinutes
} from 'date-fns';
import { lessonDialogData } from 'src/app/models/lesson/lessonDialogData.model';
import { deletedLessonInfo } from 'src/app/models/lesson/deletedLessonInfo.model';
import { insertedLessonInfo } from 'src/app/models/lesson/lnsertedLessonInfo.model';
import { LessonRepositoryService } from 'src/app/services/lesson-repository.service';
import { Console } from '@angular/core/src/console';

@Component({
  selector: 'app-lesson-dialog',
  templateUrl: './lesson-dialog.component.html',
  styleUrls: ['./lesson-dialog.component.css']
})
export class LessonDialogComponent implements OnInit {
  
  ngOnInit(): void {
    this.pupilRep.getPupils().subscribe(
      response => {
        this.pupils = response.map(p=>{
          return {
            Id: p.id,
            Name:p.name
        }})
      }
    );   
  }

  lessonForm: FormGroup;
  changeInfo: changeLessonInfo;
  lessonInfo: lessonInfo;
  title: string;
  isNew:boolean;

  pupils: dict[];
  lessonsDurations: dict[] = lessonsDurations;

  constructor(public dialogRef: MatDialogRef<LessonDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public data : lessonDialogData,
    private pupilRep: PupilRepositoryService,
    private lessonRep: LessonRepositoryService,
    private fb:FormBuilder) {
    console.log(data);
      this.lessonForm = this.fb.group({
        pupilId: ['0', Validators.min(1)],
        lessonsDate: new FormControl(new Date(), Validators.required),
        lessonsTime:['', Validators.required],
        lessonsDuration:['', Validators.required]
      });
      if(data.calendarEvent!=null){
        this.isNew = false;
        this.lessonInfo = data.calendarEvent.meta;
        this.initFormValues(data.calendarEvent.meta,data.initDate);
        this.title = "Данные о занятии";
      }else{
        this.isNew = true;
        this.title = "Добавить новое занятие";
        this.initFormValues(null,data.initDate);
      }   
  }

  initFormValues(data:lessonInfo,startDate:Date){
    if(data!=null){
      this.lessonForm.patchValue({
        pupilId: data.pupilId,
        lessonsDate:data.startDate,
        lessonsTime:format(data.startDate,'HH:mm'),
        lessonsDuration:data.lessonDuration
      });
    }else{
      this.lessonForm.patchValue({
        lessonsDate:startDate || new Date(),
        lessonsTime:format(startDate || new Date(),'HH:mm')
      });
    }
  }

  public closeDialog(){
    this.dialogRef.close();
  }

  private getDeletedInfo():deletedLessonInfo{
    if (this.isNew){
      return null;
    }
    return {
      lessonDate : this.lessonInfo.startDate,
      lessonType : this.lessonInfo.lessonInfoType,
      id : this.lessonInfo.id
    }
  }

  private getInseredInfo():insertedLessonInfo{
    let lessonsDate = parse(this.lessonForm.get('lessonsDate').value);
    let lessonsTime = String(this.lessonForm.get('lessonsTime').value).split(':');
    let lessonDateTime = addMinutes(addHours(lessonsDate,Number(lessonsTime[0])),Number(lessonsTime[1]));
    //console.log(lessonDateTime);
    return {
      lessonsDateTime : lessonDateTime,
      lessonsDuration :  this.lessonForm.get('lessonsDuration').value,
    };
  }

  saveLesson(){
    let changeLessonInfo = {
      pupilId : this.lessonForm.get('pupilId').value,
      insertedInfo: this.getInseredInfo(),
      deletedInfo: this.getDeletedInfo()
    }
    console.log(changeLessonInfo);
    this.lessonRep.changeLesson(changeLessonInfo).subscribe(()=> this.dialogRef.close('updated'));
  }

  deleteLesson(){
    let changeLessonInfo = {
      pupilId : this.lessonForm.get('pupilId').value,
      insertedInfo: null,
      deletedInfo: this.getDeletedInfo()
    }
    this.lessonRep.changeLesson(changeLessonInfo).subscribe(()=> this.dialogRef.close('updated'));
  }

}
