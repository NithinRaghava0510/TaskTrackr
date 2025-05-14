import { bootstrapApplication } from '@angular/platform-browser';
import { importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app/app.component';
import { TaskListComponent } from './app/components/task-list/task-list.component';
import { TaskFormComponent } from './app/components/task-form/task-form.component';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(HttpClientModule, FormsModule),
    provideRouter([
      { path: '',      component: TaskListComponent },
      { path: 'add',   component: TaskFormComponent },
      { path: 'edit/:id', component: TaskFormComponent },
    ])
  ]
}).catch(err => console.error(err));
