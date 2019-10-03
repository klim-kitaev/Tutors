import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import localeRu from '@angular/common/locales/ru';

import {FlexLayoutModule} from "@angular/flex-layout";
import { MyOwnCustomMaterialModule } from './custom-material.module';
import { AlertDialogComponent } from './components/common/alert-dialog/alert-dialog.component';
import { PupilListComponent } from './components/pupil-list/pupil-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ConfigService } from './services/config.service';
import { PupilListDeleteComponent } from './components/pupil-list/pupil-list-delete/pupil-list-delete.component';
import { PupilListEditComponent } from './components/pupil-list/pupil-list-edit/pupil-list-edit.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CalendarComponent } from './components/calendar/calendar.component';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { registerLocaleData } from '@angular/common';
import { CalendarHeaderComponent } from './components/calendar/calendar-header/calendar-header.component';
import { CalendarDataComponent } from './components/calendar/calendar-data/calendar-data.component';
import { LessonDialogComponent } from './components/calendar/lesson-dialog/lesson-dialog.component';
import { OAuthService } from './services/oauth.service';
import { AUTH_CONFIG, OPEN_ID_AUTH_CONFIG } from './services/auth-config';
import { CallbackComponent } from './components/auth/callback/callback.component';

registerLocaleData(localeRu);

@NgModule({
  declarations: [
    AppComponent,
    AlertDialogComponent,
    PupilListComponent,
    PupilListDeleteComponent,
    PupilListEditComponent,
    CalendarComponent,
    CalendarHeaderComponent,
    CalendarDataComponent,
    LessonDialogComponent,
    CallbackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FlexLayoutModule,
    MyOwnCustomMaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    CalendarModule.forRoot({
      provide:DateAdapter,
      useFactory:adapterFactory
    }),
  ],
  entryComponents:[AlertDialogComponent,
                  PupilListDeleteComponent,
                  PupilListEditComponent,
                  LessonDialogComponent],
  providers: [ConfigService,
              OAuthService,
              {provide: AUTH_CONFIG, useValue: OPEN_ID_AUTH_CONFIG}],
  bootstrap: [AppComponent]
})
export class AppModule { }
