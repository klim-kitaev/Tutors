import { Component, OnInit } from '@angular/core';
import { PupilRepositoryService } from 'src/app/services/pupil-repository.service';
//import { BaseComponent } from '../base.component';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { pupilInfo } from 'src/app/models/pupil/pupilInfo.model';
import { pupilInfoListItem } from 'src/app/models/pupil/pupilInfoListItem.model';
import { AlertDialogComponent } from '../common/alert-dialog/alert-dialog.component';
import { PupilListDeleteComponent } from './pupil-list-delete/pupil-list-delete.component';
import { PupilListEditComponent } from './pupil-list-edit/pupil-list-edit.component';

@Component({
  selector: 'app-pupil-list',
  templateUrl: './pupil-list.component.html',
  styleUrls: ['./pupil-list.component.css']
})
export class PupilListComponent implements OnInit {

  pupipleList: pupilInfoListItem[];
  displayedColumns = ['view',
                      'delete',
                      'name',
                      'timeInMonday',
                      'timeInTuesday',
                      'timeInWednesday',
                      'timeInThursday',
                      'timeInFirday',
                      'timeInSaturday',
                      'timeInSunday'
                    ];
  dataSource = new MatTableDataSource(this.pupipleList);

  constructor(private pupilRep:PupilRepositoryService,public dialog : MatDialog) {    
  }

  ngOnInit() {
    this.refreshList();
  }

  private refreshList(){
    this.pupilRep.getPupils().subscribe(
      pupiles=>{
        this.pupipleList=pupiles,
        this.dataSource = new MatTableDataSource(pupiles);
      },
      error=>this.showAllert(error));
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  showAllert(alert : string) : void {
    console.log(alert);
    this.dialog.open(AlertDialogComponent, {
      data: alert,width : '250px'
    });
  }

  delete(row : pupilInfoListItem){
    let dialogRef = this.dialog.open(PupilListDeleteComponent, {
      data: row,
    });
    dialogRef.afterClosed().subscribe(result=>{
      if(result=='deleted'){
        this.refreshList();
      }
    });
  }

  edit(row : pupilInfoListItem){
    let dialogRef = this.dialog.open(PupilListEditComponent, {
      data: row,width : '600px',height:'600px'
    });
    dialogRef.afterClosed().subscribe(result=>{
      if(result=='updated'){
        console.log('refresh');
        this.refreshList();
      }
    });
  }

  add(){
    let dialogRef = this.dialog.open(PupilListEditComponent, {
      data: null,width : '600px',height:'600px'
    });
    dialogRef.afterClosed().subscribe(result=>{
      if(result=='updated'){
        this.refreshList();
      }
    })
  }

}
