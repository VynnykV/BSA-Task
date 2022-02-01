import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {Router} from "@angular/router";
import {UserService} from "../../user.service";
import {NewUser} from "../../../../models/user/new-user";
import {Team} from "../../../../models/team/team";
import {TeamService} from "../../../team/team.service";

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {

  teams: Team[] = [];

  form!: FormGroup;

  constructor(
    private userService: UserService,
    private teamService: TeamService,
    private formBuilder: FormBuilder,
    protected router: Router
  ) { }

  ngOnInit(): void {
    this.teamService
      .getTeams()
      .subscribe((resp) => {
        this.teams = resp;
      });

    this.form = this.formBuilder.group({
      team: [null],
      firstName: [''],
      lastName: [''],
      email: [''],
      birthDay: ['']
    });
  }

  public createUser() {
    let formValue = this.form.value;
    let newUser =
      {
        teamId: formValue.team?.id,
        firstName: formValue.firstName,
        lastName: formValue.lastName,
        email: formValue.email,
        birthDay: formValue.birthDay
      } as NewUser;
    this.userService
      .createUser(newUser)
      .subscribe(() => {
        this.router.navigate(['users']);
      });
  }

}
