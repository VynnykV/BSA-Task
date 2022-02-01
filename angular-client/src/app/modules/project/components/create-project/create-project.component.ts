import { Component, OnInit } from '@angular/core';
import {Team} from "../../../../models/team/team";
import {FormBuilder, FormGroup} from "@angular/forms";
import {ProjectService} from "../../../project/project.service";
import {TeamService} from "../../../team/team.service";
import {Router} from "@angular/router";
import {NewProject} from "../../../../models/project/new-project";
import {User} from "../../../../models/user/user";
import {UserService} from "../../../user/user.service";

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css']
})
export class CreateProjectComponent implements OnInit {

  teams: Team[] = [];
  authors: User[] = [];

  form!: FormGroup;

  constructor(
    private projectService: ProjectService,
    private teamService: TeamService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    protected router: Router
  ) { }

  ngOnInit(): void {
    this.teamService
      .getTeams()
      .subscribe((resp) => {
        this.teams = resp;
      });

    this.userService
      .getUsers()
      .subscribe((resp) => {
        this.authors = resp;
      })

    this.form = this.formBuilder.group({
      author: [null],
      team: [null],
      name: [''],
      description: [''],
      deadline: ['']
    });
  }

  public createProject() {
    let formValue = this.form.value;
    let newProject =
      {
        authorId: formValue.author.id,
        teamId: formValue.team?.id,
        name: formValue.name,
        description: formValue.description,
        deadline: formValue.deadline
      } as NewProject;
    this.projectService
      .createProject(newProject)
      .subscribe(() => {
        this.router.navigate(['projects']);
      });
  }

}
