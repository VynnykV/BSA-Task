import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { GreetingComponent } from './components/greeting/greeting.component';
import { TeamModule } from "./modules/team/team.module";
import {UserModule} from "./modules/user/user.module";
import {ProjectModule} from "./modules/project/project.module";
import {TaskModule} from "./modules/task/task.module";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GreetingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TeamModule,
    UserModule,
    ProjectModule,
    TaskModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
