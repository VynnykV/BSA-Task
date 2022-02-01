import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ProjectsComponent} from "./components/projects/projects.component";
import {EditProjectComponent} from "./components/edit-project/edit-project.component";
import {CreateProjectComponent} from "./components/create-project/create-project.component";

const routes: Routes = [
  { path : 'projects', component : ProjectsComponent, pathMatch: 'full'},
  { path : 'edit-project/:id', component : EditProjectComponent, pathMatch: 'full'},
  { path : 'create-project', component : CreateProjectComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
