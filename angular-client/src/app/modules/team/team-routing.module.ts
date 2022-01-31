import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeamsComponent } from "./components/teams/teams.component";
import { EditTeamComponent } from "./components/edit-team/edit-team.component";
import { CreateTeamComponent } from "./components/create-team/create-team.component";

const routes: Routes = [
  { path : 'teams', component : TeamsComponent, pathMatch: 'full'},
  { path : 'edit-team/:id', component : EditTeamComponent, pathMatch: 'full'},
  { path : 'create-team', component : CreateTeamComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TeamRoutingModule { }
