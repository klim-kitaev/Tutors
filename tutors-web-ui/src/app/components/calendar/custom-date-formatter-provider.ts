import { CalendarDateFormatter, DateFormatterParams } from 'angular-calendar';
import { DatePipe } from '@angular/common';

export class CustomDateFormatter extends CalendarDateFormatter {

    public dayViewHour({ date, locale }: DateFormatterParams): string {
        return new DatePipe(locale).transform(date, 'HH:mm', locale);
      }
      public weekViewHour({ date, locale }: DateFormatterParams): string {
        return new DatePipe(locale).transform(date, 'HH:mm', locale);
      }
      
}