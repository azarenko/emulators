    processor 12F675
    org 0

; This shorthand assigns COUNT1=0x20, COUNT2=0x21, etc.
    cblock 0x20
        COUNT1
        COUNT2
        COUNT3
    endc

; See "Section 27. Device Configuration Bits" of the "PICmicro™ Mid-Range MCU
; Family Reference Manual"
; (http://ww1.microchip.com/downloads/en/DeviceDoc/33023a.pdf).

; _INTRC_OSC_NOCLKOUT: we want to use the internal oscillator to drive the PIC,
; so that we don't need to connect a crystal, see "Section 2. Oscillator".

; _WDT_OFF: disable the watchdog timer, which if enabled would reset the PIC
; every 18ms, see "Section 26. Watchdog Timer and Sleep Mode".
;
; _PWRTE_ON: enable the power-up timer, which instructs the MPU to wait about
; 72ms to give time for Vdd to reach a stable voltage, see "9.3.3 POWER-UP TIMER
; (PWRT)".
;
; _MCLRE_OFF: if "Master Clear" is enabled, pin 4/GP3 is the reset pin, so
; you'd need to supply Vdd on that pin. By disabling this, GP3 becomes available
; for I/O.

    #include <p12f675.inc>
    __config _INTRC_OSC_NOCLKOUT & _WDT_OFF & _PWRTE_ON & _MCLRE_OFF

; The PIC assembler will warn every time you try to use a register that isn't
; in Bank 0. The warning is annoying and unnecessary.
    errorlevel -302

	nop
	nop
	nop
	goto $-1
goto $-1
goto $-1
goto $-1

    end
