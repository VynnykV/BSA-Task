import { Component, OnInit } from '@angular/core';
import {Team} from "../../../../models/team/team";
import {FormBuilder, FormGroup} from "@angular/forms";
import {ProjectService} from "../../../project/project.service";
import {TeamService} from "../../../team/team.service";
import {ActivatedRoute, Router} from "@angular/router";
import {UpdateProject} from "../../../../models/project/update-project";

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css']
})
export class EditProjectComponent implements OnInit {

  teams: Team[] = [];

  public form: FormGroup;
  public id: number;

  constructor(
    private projectService: ProjectService,
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
      name: [''],
      description: [''],
      deadline: ['']
    });

    this.id = this.route.snapshot.params['id'];

    this.projectService.getProjectById(this.id).subscribe(
      project => {
        this.form.patchValue(project);
        this.form.controls['team'].patchValue(this.teams.find(t=>t.id == project.team.id));
      }
    )
  }

  public updateProject() {
    let formValue = this.form.value;
    let updatedProject =
      {
        id : this.id,
        teamId: formValue.team.id,
        name: formValue.name,
        description: formValue.description,
        deadline: formValue.deadline
      } as UpdateProject;
    this.projectService
      .updateProject(updatedProject)
      .subscribe(() => {
        this.router.navigate(['projects']);
      });
  }
}
