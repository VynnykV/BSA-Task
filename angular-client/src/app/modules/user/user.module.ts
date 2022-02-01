import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { UsersComponent } from './components/users/users.component';
import {UserService} from "./user.service";
import {ReactiveFormsModule} from "@angular/forms";
import {CustomDatePipe} from "./pipes/custom-date.pipe";
import {LeaveEditingGuard} from "./guards/leave-editing.guard";


@NgModule({
  declarations: [
    CreateUserComponent,
    EditUserComponent,
    UsersComponent,
    CustomDatePipe
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService, LeaveEditingGuard
  ]
})
export class UserModule { }
