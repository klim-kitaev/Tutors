import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from '../models/config/config.model';
import { share,map} from 'rxjs/operators';
import { Observable } from 'rxjs';

const configUrl = 'assets/config.json';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {


  constructor(private http:HttpClient) {     
  }

  public getConfig(): Observable<Config>{
    return this.http.get<Config>(configUrl);  
  }

  
}
