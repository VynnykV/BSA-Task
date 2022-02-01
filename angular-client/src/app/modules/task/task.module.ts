import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskRoutingModule } from './task-routing.module';
import { CreateTaskComponent } from './components/new-task/create-task.component';
import { EditTaskComponent } from './components/edit-task/edit-task.component';
import {TaskService} from "./task.service";
import { ProjectTasksComponent } from './components/project-tasks/project-tasks.component';
import {ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    CreateTaskComponent,
    EditTaskComponent,
    ProjectTasksComponent
  ],
    imports: [
        CommonModule,
        TaskRoutingModule,
        ReactiveFormsModule
    ],
  providers: [
    TaskService
  ]
})
export class TaskModule { }
