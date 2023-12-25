import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
    ]),
  });

  constructor(
    private auth: AuthService,
    private snackbar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params: Params) => {
      if (params['nowCanLogin']) {
        this.snackbar.open('Теперь вы можете зайти в систему');
      }
    });
  }

  submitLogin() {
    this.auth
      .login(this.loginForm.value.email, this.loginForm.value.password)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.auth.currentUserId = res;
          window.localStorage.setItem('userId', res.toString());
          this.router.navigate(['/system', 'products']);
          this.snackbar.open('Успешный вход в систему!');
        },
        error: (err) => {
          this.snackbar.open('Ошибка входа в систему!');
        },
      });
  }

  clearLogin() {
    this.loginForm.get('email')?.setValue('');
  }

  clearPassword() {
    this.loginForm.get('password')?.setValue('');
  }

  fillForm() {
    this.loginForm.patchValue({
      email: 'abc@abc',
      password: 'admin123',
    });
  }
}
