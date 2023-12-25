import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RegisterComponent {
  registerForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
    ]),
    name: new FormControl('', [Validators.required]),
    agree: new FormControl(false, [Validators.requiredTrue]),
  });

  constructor(private auth: AuthService, private router: Router) {}

  submitRegistration() {
    const { email, password, name } = this.registerForm.value;
    const user = new User(email, password, name);
    this.auth.createNewUser(user).subscribe((res: any) => {
      this.router.navigate(['/auth/login'], {
        queryParams: {
          nowCanLogin: true,
        },
      });
    });
  }

  clearLogin() {
    this.registerForm.get('email')?.setValue('');
  }

  clearPassword() {
    this.registerForm.get('password')?.setValue('');
  }
}
