import {Component, OnDestroy, OnInit} from '@angular/core';
import {Team} from "../../../../models/team/team";
import {TeamService} from "../../team.service";
import {Subject, takeUntil} from "rxjs";

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit, OnDestroy {
  public teams: Team[] = [];

  private unsubscribe$ = new Subject<void>();

  constructor(private teamService: TeamService) { }

  ngOnInit(): void {
    this.getTeams();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public getTeams() {
    this.teamService
      .getTeams()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (resp) => {
          this.teams = resp;
        }
      )
  }

  public deleteTeam(id: number) {
    this.teamService
      .deleteTeam(id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(() => {
        this.teams = this.teams.filter(t=>t.id !== id);
      })
  }

}
