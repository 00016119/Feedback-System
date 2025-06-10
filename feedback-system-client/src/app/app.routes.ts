import { Routes } from '@angular/router';
import { FeedbackListComponent } from './components/feedback/feedback-list/feedback-list';
import { FeedbackCreateComponent } from './components/feedback/feedback-create/feedback-create';
import { FeedbackEditComponent } from './components/feedback/feedback-edit/feedback-edit';

export const routes: Routes = [
  { path: '', redirectTo: 'feedbacks', pathMatch: 'full' },
  { path: 'feedbacks', component: FeedbackListComponent },
  { path: 'feedbacks/create', component: FeedbackCreateComponent },
  { path: 'feedbacks/edit/:id', component: FeedbackEditComponent },
  { path: '**', redirectTo: 'feedbacks' }
];
