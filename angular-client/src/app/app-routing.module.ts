import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GreetingComponent} from "./components/greeting/greeting.component";

const routes: Routes =
  [
    { path: '', component: GreetingComponent, pathMatch: 'full' },
    { path: '**', redirectTo: '' }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
