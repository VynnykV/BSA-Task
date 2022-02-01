import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectTasksComponent } from "./components/project-tasks/project-tasks.component";
import { EditTaskComponent } from "./components/edit-task/edit-task.component";
import { CreateTaskComponent } from "./components/create-task/create-task.component";
import {SetTaskStateComponent} from "./components/set-task-state/set-task-state.component";

const routes: Routes = [
  { path : 'project-tasks/:id', component : ProjectTasksComponent, pathMatch: 'full'},
  { path : 'edit-task/:id', component : EditTaskComponent, pathMatch: 'full'},
  { path : 'project-tasks/:id/create-task', component : CreateTaskComponent, pathMatch: 'full'},
  { path : 'set-task-state/:id', component : SetTaskStateComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaskRoutingModule { }
