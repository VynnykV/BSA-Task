import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {UpdateTeam} from "../../../../models/team/update-team";
import {TeamService} from "../../team.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-edit-team',
  templateUrl: './edit-team.component.html',
  styleUrls: ['./edit-team.component.css']
})
export class EditTeamComponent implements OnInit {

  public form!: FormGroup;
  public id!: number;

  constructor(
    private teamService: TeamService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['']
    });

    this.id = this.route.snapshot.params['id'];

    this.teamService.getTeamById(this.id).subscribe(
      team => this.form.patchValue(team)
    )
  }

  public updateTeam() {
    let formValue = this.form.value;
    let updatedTeam =
      {
        id : this.id,
        name : formValue.name
      } as UpdateTeam;
    this.teamService
      .updateTeam(updatedTeam)
      .subscribe(() => {
        this.router.navigate(['teams']);
      });
  }
}
