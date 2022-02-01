import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GreetingComponent } from "./components/greeting/greeting.component";
import {TeamRoutingModule} from "./modules/team/team-routing.module";
import {UserRoutingModule} from "./modules/user/user-routing.module";
import {ProjectRoutingModule} from "./modules/project/project-routing.module";
import {TaskRoutingModule} from "./modules/task/task-routing.module";

const routes: Routes =
  [
    { path: '', component: GreetingComponent, pathMatch: 'full' },
    { path: '**', redirectTo: '' },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes), TeamRoutingModule, UserRoutingModule, ProjectRoutingModule, TaskRoutingModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
