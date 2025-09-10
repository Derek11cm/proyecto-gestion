export default function StatCard({ title, value }) {
  return (
    <div className="bg-white shadow rounded-lg p-6">
      <h3 className="text-lg font-medium text-gray-500">{title}</h3>
      <p className="mt-1 text-4xl font-semibold text-gray-900">{value}</p>
    </div>
  );
}