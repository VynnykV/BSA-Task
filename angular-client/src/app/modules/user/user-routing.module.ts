import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UsersComponent} from "./components/users/users.component";
import {EditUserComponent} from "./components/edit-user/edit-user.component";
import {CreateUserComponent} from "./components/create-user/create-user.component";
import {LeaveEditingGuard} from "./guards/leave-editing.guard";

const routes: Routes = [
  { path : 'users', component : UsersComponent, pathMatch: 'full'},
  { path : 'edit-user/:id', component : EditUserComponent, pathMatch: 'full', canDeactivate: [LeaveEditingGuard]},
  { path : 'create-user', component : CreateUserComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
