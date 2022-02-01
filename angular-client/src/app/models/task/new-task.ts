import {TaskState} from "./TaskState";

export interface NewTask {
  projectId: number;
  performerId: number;
  name: string;
  description: string;
  taskState: TaskState;
}
