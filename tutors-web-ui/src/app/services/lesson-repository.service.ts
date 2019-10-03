import { Injectable } from '@angular/core';
import { BaseRepositoryService } from './base-repository.service';
import { LessonRequest } from '../models/lesson/lessonRequest.model';
import { lessonInfo } from '../models/lesson/lessonInfo.model';
import { changeLessonInfo } from '../models/lesson/changeLessonInfo.model';

@Injectable({
  providedIn: 'root'
})
export class LessonRepositoryService {

  constructor(private baseRep:BaseRepositoryService) { }

  getLessons(lessonRequest: LessonRequest){
    return this.baseRep.get<lessonInfo[]>(`Lessons?startDate=${lessonRequest.startDate}&endDate=${lessonRequest.endDate}`);
  }

  changeLesson(changeLessonInfo:changeLessonInfo){
    return this.baseRep.post("Lessons",changeLessonInfo);
  }

}
