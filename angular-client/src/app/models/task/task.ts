import {TaskState} from "./TaskState";
import {Project} from "../project/project";
import {User} from "../user/user";

export interface Task {
  id: number;
  project: Project;
  performer: User;
  name: string;
  description: string;
  taskState: TaskState;
  createdAt: Date;
  finishedAt?: Date;
}
