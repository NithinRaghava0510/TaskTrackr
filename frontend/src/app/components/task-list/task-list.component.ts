import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Task } from '../../models/task';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private svc: TaskService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.svc.getAll().subscribe(data => this.tasks = data);
  }

  delete(id: number) {
    this.svc.delete(id).subscribe(() => this.load());
  }

  toggle(task: Task) {
    task.isComplete = !task.isComplete;
    this.svc.update(task).subscribe();
  }
}
