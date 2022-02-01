import { Component, OnInit } from '@angular/core';
import {User} from "../../../../models/user/user";
import {FormBuilder, FormGroup} from "@angular/forms";
import {TaskService} from "../../../task/task.service";
import {TeamService} from "../../../team/team.service";
import {UserService} from "../../../user/user.service";
import {ActivatedRoute, Router} from "@angular/router";
import {NewTask} from "../../../../models/task/new-task";

@Component({
  selector: 'app-new-tasks',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  authors: User[] = [];

  form!: FormGroup;
  projectId: number;

  constructor(
    private taskService: TaskService,
    private teamService: TeamService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    protected router: Router
  ) { }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.params['id'];

    this.userService
      .getUsers()
      .subscribe((resp) => {
        this.authors = resp;
      })

    this.form = this.formBuilder.group({
      performer: [null],
      name: [''],
      description: [''],
      taskState: ['']
    });
  }

  public createTask() {
    let formValue = this.form.value;
    let newTask =
      {
        projectId: this.projectId,
        performerId: formValue.performer.id,
        name: formValue.name,
        description: formValue.description,
        taskState: formValue.taskState
      } as NewTask;
    this.taskService
      .createTask(newTask)
      .subscribe(() => {
        this.router.navigate(['/project-tasks',this.projectId]);
      });
  }

}
