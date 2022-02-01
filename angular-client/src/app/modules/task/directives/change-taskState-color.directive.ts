import {AfterViewInit, Directive, ElementRef, Input} from '@angular/core';
import {TaskState} from "../../../models/task/TaskState";

@Directive({
  selector: '[ChangeTaskStateColor]'
})
export class ChangeTaskStateColorDirective implements AfterViewInit {

  @Input() taskState: TaskState;

  constructor(private el: ElementRef) {
  }

  ngAfterViewInit(): void {
    switch (this.taskState){
      case TaskState.Created:
        this.el.nativeElement.style.color = 'grey';
        break;
      case TaskState.Cancelled:
        this.el.nativeElement.style.color = 'red';
        break;
      case TaskState.Done:
        this.el.nativeElement.style.color = 'green';
        break;
      case TaskState.InProgress:
        this.el.nativeElement.style.color = 'yellow';
        break;
    }
  }


}
