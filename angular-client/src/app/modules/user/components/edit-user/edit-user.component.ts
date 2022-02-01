import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {UserService} from "../../user.service";
import {UpdateUser} from "../../../../models/user/update-user";
import {Team} from "../../../../models/team/team";
import {TeamService} from "../../../team/team.service";
import {ComponentCanDeactivate} from "../../guards/leave-editing.guard";
import {Observable} from "rxjs";

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit, ComponentCanDeactivate {

  teams: Team[] = [];

  public form!: FormGroup;
  public id!: number;

  constructor(
    private userService: UserService,
    private teamService: TeamService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
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

    this.id = this.route.snapshot.params['id'];

    this.userService.getUserById(this.id).subscribe(
      user => {
        this.form.patchValue(user);
        this.form.controls['team'].patchValue(this.teams.find(t=>t.id == user.team?.id));
      }
    )
  }

  public updateUser() {
    let formValue = this.form.value;
    let updatedUser =
      {
        id : this.id,
        teamId: formValue.team?.id,
        firstName : formValue.firstName,
        lastName : formValue.lastName,
        email: formValue.email,
        birthDay: formValue.birthDay
      } as UpdateUser;
    this.userService
      .updateUser(updatedUser)
      .subscribe(() => {
        this.router.navigate(['users']);
      });
  }

  canDeactivate(): boolean | Observable<boolean> {
    return confirm("There are unsaved changes. Leave page?");;
  }

}
