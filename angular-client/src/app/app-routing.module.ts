import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GreetingComponent } from "./components/greeting/greeting.component";
import {TeamRoutingModule} from "./modules/team/team-routing.module";

const routes: Routes =
  [
    { path: '', component: GreetingComponent, pathMatch: 'full' },
    { path: '**', redirectTo: '' },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes), TeamRoutingModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
