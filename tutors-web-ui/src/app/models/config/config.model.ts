import { Observable } from 'rxjs';

export interface Config{
    serviceUrl : Observable<string>;
}