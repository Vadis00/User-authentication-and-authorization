import {
  Component,
  EventEmitter,
  forwardRef,
  Input,
  Output,
} from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => InputComponent),
    },
  ],
})
export class InputComponent implements ControlValueAccessor {
  public inputClass = 'input';
  public inputType = 'text';
  @Input() public inputValue = '';
  @Input() public inputText = '';
  public inputLabel = '';
  public inputPlaceholder = '';
  public inputErrorMessage = 'error';
  public inputValueIsError = false;

 

  @Input() value="";

  @Input()
  set type(typeName: string) {
    this.inputType = typeName;
  }
  get type(): string {
    return this.inputType;
  }

  @Input()
  set placeholder(text: string) {
    this.inputPlaceholder = text;
  }
  get placeholder(): string {
    return this.inputPlaceholder;
  }

  @Input()
  set label(text: string) {
    this.inputLabel = text;
  }
  get label(): string {
    return this.inputLabel;
  }

  @Input()
  set class(name: string) {
    this.inputClass = name;
  }
  get class(): string {
    return this.inputClass;
  }

  @Input()
  set invalid(hasError: boolean) {
    this.inputValueIsError = hasError;
  }
  get invalid(): boolean {
    return this.inputValueIsError;
  }

  @Input()
  set errorMessage(message: string) {
    this.inputErrorMessage = message;
  }
  get errorMessage(): string {
    return this.inputErrorMessage;
  }
 

  @Output() iconClick = new EventEmitter<MouseEvent>();
  @Output() outputValue = new EventEmitter<string>();

  emitClick(args: MouseEvent): void {
    this.iconClick.emit(args);
  }

  onChange: (value: Event) => void = () => {};

  onTouched: (value: Event) => void = () => {};

  constructor() {}

  writeValue(value: string): void {
    this.inputValue = value;
  }

  registerOnChange(fn: (value: Event) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: (value: Event) => void): void {
    this.onTouched = fn;
  }

  emitValueChange(): void {
    this.outputValue.emit(String(this.inputValue));
  }
}