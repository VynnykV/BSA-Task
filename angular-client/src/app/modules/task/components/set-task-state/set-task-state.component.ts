import { Component, OnInit } from '@angular/core';
import {TaskService} from "../../task.service";
import {ActivatedRoute} from "@angular/router";
import {Location} from "@angular/common";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-set-task-state',
  templateUrl: './set-task-state.component.html',
  styleUrls: ['./set-task-state.component.css']
})
export class SetTaskStateComponent implements OnInit {

  public form!: FormGroup;

  id!: number;

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.form = this.formBuilder.group({
      state: ['']
    });
    this.taskService.getTaskById(this.id).subscribe(
      task => {
        this.form.controls['state'].patchValue(task.state);
      }
    )
  }

  public updateState(){
    let formValue = this.form.value;
    this.taskService
      .setNewState(this.id, formValue.state)
      .subscribe(() => {
        this.location.back();
      })
  }

}
