import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {UserService} from "../../../user/user.service";
import {TaskService} from "../../../task/task.service";
import {ActivatedRoute} from "@angular/router";
import {User} from "../../../../models/user/user";
import {UpdateTask} from "../../../../models/task/update-task";
import {Location} from '@angular/common';

@Component({
  selector: 'app-edit-tasks',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {
  users: User[] = [];

  public form: FormGroup;
  public id: number;

  constructor(
    private userService: UserService,
    private taskService: TaskService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.userService
      .getUsers()
      .subscribe((resp) => {
        this.users = resp;
      });

    this.form = this.formBuilder.group({
      performer: [null],
      name: [''],
      description: ['']
    });

    this.id = this.route.snapshot.params['id'];

    this.taskService.getTaskById(this.id).subscribe(
      task => {
        this.form.patchValue(task);
        this.form.controls['performer'].patchValue(this.users.find(u=>u.id == task.performer.id));
      }
    )
  }

  public updateTask() {
    let formValue = this.form.value;
    let updatedTask =
      {
        id : this.id,
        performerId : formValue.performer.id,
        name : formValue.name,
        description : formValue.description
      } as UpdateTask;
    this.taskService
      .updateTask(updatedTask)
      .subscribe(() => {
        this.location.back();
      });
  }

}
