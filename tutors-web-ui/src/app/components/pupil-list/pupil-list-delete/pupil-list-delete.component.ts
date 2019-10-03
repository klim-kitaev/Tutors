import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { pupilInfoListItem } from 'src/app/models/pupil/pupilInfoListItem.model';

@Component({
  selector: 'app-pupil-list-delete',
  templateUrl: './pupil-list-delete.component.html',
  styleUrls: ['./pupil-list-delete.component.css']
})
export class PupilListDeleteComponent{

  constructor(public dialogRef: MatDialogRef<PupilListDeleteComponent>, @Inject(MAT_DIALOG_DATA) public data : pupilInfoListItem) {
  }

  public closeDialog(){
    this.dialogRef.close();
  }

  public delete(id: number){
    console.log(`delete pupil ${id}`);
    this.dialogRef.close('deleted');
  }

}
