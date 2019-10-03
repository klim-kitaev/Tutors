import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { pupilInfoListItem } from 'src/app/models/pupil/pupilInfoListItem.model';
import { PupilRepositoryService } from 'src/app/services/pupil-repository.service';
import { pupilInfo } from 'src/app/models/pupil/pupilInfo.model';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import {dayOfWeeks,lessonsDurations} from 'src/app/models/common/global';
import { dict } from 'src/app/models/common/dict';


@Component({
  selector: 'app-pupil-list-edit',
  templateUrl: './pupil-list-edit.component.html',
  styleUrls: ['./pupil-list-edit.component.css']
})
export class PupilListEditComponent {

  pupil: pupilInfo;
  error_message: string;
  pupilForm: FormGroup;

  dayOfWeeks: dict[] = dayOfWeeks;
  lessonsDurations: dict[] = lessonsDurations;
 

  constructor(public dialogRef: MatDialogRef<PupilListEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: pupilInfoListItem,
    private pupilRep: PupilRepositoryService,
    private fb: FormBuilder) {
      this.initFormValues(data);    
      this.pupilForm = this.fb.group({
        id: ['0'],
        firstName: ['', Validators.required],
        lastName: [''],
        oneHourPrice: ['', Validators.required],
        oneAndHalfPrice: ['', Validators.required],
        twoHourPrice: ['', Validators.required],
        pupilSchedule:this.fb.group({
          scheduleLessons:this.fb.array([
           this.fb.group({
            lessonDay:['', Validators.required],
            lessonTime:['', Validators.required],
            lessonsDuration:['', Validators.required],
           })
          ])
        })
      });   
  }

  initFormValues(data: pupilInfoListItem){
    if (data == null) {
      this.pupil = this.initNewPupil();
    } else {
      this.pupilRep.getPupil(data.id).subscribe(pupil => {
        this.pupil = pupil;        
        //this.pupilForm.setValue(pupil);
        //Очищаем массив
        while(this.scheduleLessons.length){
          this.scheduleLessons.removeAt(0);
        }
        this.pupilForm.patchValue(pupil);
        pupil.pupilSchedule.scheduleLessons.forEach(shedule=>this.scheduleLessons.push(this.fb.group(shedule)));

        console.log(this.pupilForm.value);
      },
        error => this.error_message = error
      );
    }
  }

  addSchedule(){
    console.log('add shedule');
    this.scheduleLessons.push(this.fb.group({
      lessonDay:1,
      lessonTime:'0:00',
      lessonsDuration:1
    }));
  }
  
  get scheduleLessons(){
    return this.pupilForm.get('pupilSchedule.scheduleLessons') as FormArray
  }

  private initNewPupil(): pupilInfo {
    return {
      id: 0,
      firstName: '',
      lastName: '',
      pupilSchedule:{
        scheduleLessons:[]
      }
    }
  }

  /**Автоподсчет цены исходя из цены за час */
  public calcPrice() {
    let pricePerHour = Number(this.pupilForm.value['oneHourPrice']);
    if (pricePerHour != null) {
      this.pupilForm.patchValue({
        oneAndHalfPrice: pricePerHour * 1.5,
        twoHourPrice: pricePerHour * 2
      });
    }
  }

  public save() {
    console.log(this.pupilForm.value)
    this.pupilRep.savePupil(this.pupilForm.value)
      .subscribe(result => {
        console.log(result);
        this.dialogRef.close('updated');
      }, error => this.error_message = error);

  }

  public closeDialog() {
    this.dialogRef.close();
  }

}
