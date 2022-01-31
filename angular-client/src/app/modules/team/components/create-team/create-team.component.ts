import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {TeamService} from "../../team.service";
import {NewTeam} from "../../../../models/team/new-team";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.css']
})
export class CreateTeamComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private teamService: TeamService,
    private formBuilder: FormBuilder,
    protected router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['']
    });
  }

  public createTeam() {
    let formValue = this.form.value;
    let newTeam =
      {
        name : formValue.name
      } as NewTeam;
    this.teamService
      .createTeam(newTeam)
      .subscribe(() => {
        this.router.navigate(['teams']);
      });
  }

}
