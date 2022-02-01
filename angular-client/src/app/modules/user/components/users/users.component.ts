import {Component, OnDestroy, OnInit} from '@angular/core';
import {User} from "../../../../models/user/user";
import {UserService} from "../../user.service";
import {Subject, takeUntil} from "rxjs";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit, OnDestroy {

  public users: User[] = [];

  private unsubscribe$ = new Subject<void>();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public getUsers() {
    this.userService
      .getUsers()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (resp) => {
          this.users = resp;
        }
      )
  }

  public deleteUser(id: number) {
    this.userService
      .deleteUser(id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(() => {
        this.users = this.users.filter(t=>t.id !== id);
      })
  }

}
