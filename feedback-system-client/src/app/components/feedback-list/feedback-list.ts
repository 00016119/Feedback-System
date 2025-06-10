// Student ID: 00016119
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FeedbackService } from '../../services/feedback';
import { Feedback } from '../../models/feedback';



@Component({
  selector: 'app-feedback-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './feedback-list.html',
  styleUrls: ['./feedback-list.css']
})
export class FeedbackListComponent implements OnInit {
  feedbacks: Feedback[] = [];
  isLoading = true;

  constructor(private feedbackService: FeedbackService) {}

  ngOnInit(): void {
    this.feedbackService.getAll().subscribe({
      next: (data) => {
        this.feedbacks = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error fetching feedbacks', err);
        this.isLoading = false;
      }
    });
  }
}
