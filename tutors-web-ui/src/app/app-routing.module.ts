import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PupilListComponent } from './components/pupil-list/pupil-list.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { CallbackComponent } from './components/auth/callback/callback.component';

const routes: Routes = [
  { path: 'pupils', component: PupilListComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: 'callback.html', component: CallbackComponent },
  { path: '', redirectTo: '/pupils', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
