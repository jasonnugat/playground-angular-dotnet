import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './features//home/sidebar/sidebar.component';
import { AuthenticationService } from './core/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [RouterModule, CommonModule, SidebarComponent]
})
export class AppComponent {
  constructor(public authService: AuthenticationService) { }
}