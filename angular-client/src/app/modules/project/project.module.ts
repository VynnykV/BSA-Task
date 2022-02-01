import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectRoutingModule } from './project-routing.module';
import { ProjectsComponent } from './components/projects/projects.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { EditProjectComponent } from './components/edit-project/edit-project.component';
import { HttpClientModule } from "@angular/common/http";
import { ProjectService } from "./project.service";
import {ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    ProjectsComponent,
    CreateProjectComponent,
    EditProjectComponent
  ],
    imports: [
        CommonModule,
        ProjectRoutingModule,
        HttpClientModule,
        ReactiveFormsModule
    ],
  providers: [
    ProjectService
  ]
})
export class ProjectModule { }
