import { createCustomerAction } from "../actions";
import SubmitButton from "@/components/submit-button";

export default function NewCustomerForm() {
  return (
    <form action={createCustomerAction} className="flex flex-wrap gap-2 items-end">
      <div>
        <label className="block text-sm">First name</label>
        <input className="border px-2 py-1" name="firstName" required />
      </div>
      <div>
        <label className="block text-sm">Last name</label>
        <input className="border px-2 py-1" name="lastName" required />
      </div>
      <div>
        <label className="block text-sm">Email</label>
        <input className="border px-2 py-1" type="email" name="email" required />
      </div>
      <SubmitButton label="Submit" pendingLabel="Submitting..." />
    </form>
  );
}
