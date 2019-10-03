import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { ConfigService } from './config.service';
import { catchError, map, share, mergeMap } from 'rxjs/operators';
import { throwError, Observable } from "rxjs";
import { OAuthService } from './oauth.service';




@Injectable({
  providedIn: 'root'
})
export class BaseRepositoryService {

  private serviceUrl$: Observable<Observable<string>>;

  constructor(private http: HttpClient, private configService: ConfigService, private oauthService: OAuthService) {
    this.serviceUrl$ = configService.getConfig().pipe(map(p => p.serviceUrl));
  }

  private GetHttpOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': "Bearer " + this.oauthService.token
      })
    }
  };


  get<T>(url: string) {
    // debugger;
    return this.serviceUrl$.pipe(mergeMap(host => this.http.get<T>(`${host}/api/${url}`, this.GetHttpOptions()).pipe(catchError(this.handleError))));
  }

  post<T>(url: string, body: any) {
    return this.serviceUrl$.pipe(mergeMap(host => this.http.post<T>(`${host}/api/${url}`, body, this.GetHttpOptions()).pipe(catchError(this.handleError))));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };



}
