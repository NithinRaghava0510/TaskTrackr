import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../models/task';

@Injectable({ providedIn: 'root' })
export class TaskService {
  private api = '/api/tasks';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Task[]> {
    return this.http.get<Task[]>(this.api);
  }

  get(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.api}/${id}`);
  }

  create(task: Task): Observable<Task> {
    return this.http.post<Task>(this.api, task);
  }

  update(task: Task): Observable<void> {
    return this.http.put<void>(`${this.api}/${task.id}`, task);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.api}/${id}`);
  }
}
