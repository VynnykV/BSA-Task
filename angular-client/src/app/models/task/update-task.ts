import {TaskState} from "./TaskState";

export interface UpdateTask {
  id: number;
  performerId: number;
  name: string;
  description: string;
  state: TaskState;
  finishedAt?: Date;
}
