import { Component, OnInit } from '@angular/core';
import {Project} from "../../../../models/project/project";
import {Subject, takeUntil} from "rxjs";
import {ProjectService} from "../../../project/project.service";

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  public projects: Project[] = [];

  private unsubscribe$ = new Subject<void>();

  constructor(private projectService: ProjectService) { }

  ngOnInit(): void {
    this.getProjects();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public getProjects() {
    this.projectService
      .getProjects()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (resp) => {
          this.projects = resp;
        }
      )
  }

  public deleteProject(id: number) {
    this.projectService
      .deleteProject(id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(() => {
        this.projects = this.projects.filter(t=>t.id !== id);
      })
  }
}
