import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, ActivatedRoute } from '@angular/router';
import { Task } from '../../models/task';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {
  task: Task = { id: 0, title: '', description: '', isComplete: false };
  isEdit = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private svc: TaskService
  ) {}

  ngOnInit() {
    const id = +this.route.snapshot.params['id'];
    if (id) {
      this.isEdit = true;
      this.svc.get(id).subscribe(t => this.task = t);
    }
  }

  submit() {
    if (this.isEdit) {
      this.svc.update(this.task).subscribe(() => this.router.navigate(['/']));
    } else {
      this.svc.create(this.task).subscribe(() => this.router.navigate(['/']));
    }
  }
}
