import { Pipe, PipeTransform } from '@angular/core';
import {DatePipe, formatDate} from "@angular/common";

const months = new Map<string, string>();
months.set("January", "Січня");
months.set("February", "Лютого");
months.set("March", "Березня");
months.set("April", "Квітня");
months.set("May", "Травня");
months.set("June", "Червня");
months.set("July", "Липня");
months.set("August", "Серпня");
months.set("September", "Вересня");
months.set("October", "Жовтня");
months.set("November", "Листопада");
months.set("December", "Грудня");

@Pipe({
  name: 'customDate'
})

export class CustomDatePipe implements PipeTransform {

  transform(value: Date): string {
    let date = new Date(value);
    let month = date.toLocaleString('en', { month: 'long' });
    let translatedMonth: string = months.get(month) || "";
    let result = new DatePipe('en').transform(date, 'dd') + " " +
      translatedMonth.toLowerCase() + " " +
      new DatePipe('en').transform(date, 'yyyy');
    return result;
  }

}
