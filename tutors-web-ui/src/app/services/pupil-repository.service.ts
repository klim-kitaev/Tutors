import { Injectable } from '@angular/core';
import { pupilInfoListItem } from '../models/pupil/pupilInfoListItem.model';
import { Observable } from 'rxjs';
import { BaseRepositoryService } from './base-repository.service';
import { pupilInfo } from '../models/pupil/pupilInfo.model';

@Injectable({
  providedIn: 'root'
})
export class PupilRepositoryService {

  constructor(private baseRep:BaseRepositoryService) { 
  }

  getPupils(){
    return this.baseRep.get<pupilInfoListItem[]>("pupil");
  }

  getPupil(id:number){
    return this.baseRep.get<pupilInfo>(`pupil/${id}`);
  }

  savePupil(body:any){
    return this.baseRep.post<pupilInfo>("pupil",body);
  }
}
