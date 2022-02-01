import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeamRoutingModule } from './team-routing.module';
import { TeamsComponent } from "./components/teams/teams.component";
import { EditTeamComponent } from "./components/edit-team/edit-team.component";
import { CreateTeamComponent } from "./components/create-team/create-team.component";
import { ReactiveFormsModule } from "@angular/forms";
import { TeamService } from "./team.service";
import {HttpClientModule} from "@angular/common/http";


@NgModule({
  declarations: [TeamsComponent, EditTeamComponent, CreateTeamComponent],
  imports: [
    CommonModule,
    TeamRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    TeamService
  ]
})
export class TeamModule { }
