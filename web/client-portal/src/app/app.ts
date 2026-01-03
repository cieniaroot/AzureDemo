import { Component, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { WeatherForecast } from './weather-forecast.interface';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected readonly title = signal('Weather Forecast Portal');
  protected forecasts = signal<WeatherForecast[]>([]);

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<WeatherForecast[]>('http://localhost:5000/weatherforecast')
      .subscribe({
        next: (data) => this.forecasts.set(data),
        error: (err) => console.error('Failed to fetch weather data', err)
      });
  }
}