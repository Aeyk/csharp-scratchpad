using System.Runtime.CompilerServices;

namespace System.Threading.Tasks;

/// <summary>Represents an asynchronous operation that can return a value.</summary>
/// <typeparam name="TResult">The type of the result produced by this <see cref="T:System.Threading.Tasks.Task`1" />.</typeparam>
public class Task<TResult> : Task
{
	/// <summary>Gets a factory method for creating and configuring <see cref="T:System.Threading.Tasks.Task`1" /> instances.</summary>
	/// <returns>A factory object that can create a variety of <see cref="T:System.Threading.Tasks.Task`1" /> objects.</returns>
	public new static TaskFactory<TResult> Factory
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the result value of this <see cref="T:System.Threading.Tasks.Task`1" />.</summary>
	/// <exception cref="T:System.AggregateException">The task was canceled. The <see cref="P:System.AggregateException.InnerExceptions" /> collection contains a <see cref="T:System.Threading.Tasks.TaskCanceledException" /> object.  
	///
	///  -or-  
	///
	///  An exception was thrown during the execution of the task. The <see cref="P:System.AggregateException.InnerExceptions" /> collection contains information about the exception or exceptions.</exception>
	/// <returns>The result value of this <see cref="T:System.Threading.Tasks.Task`1" />, which is of the same type as the task's type parameter.</returns>
	public TResult Result
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified function and state.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="state">An object representing data to be used by the action.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<object?, TResult> function, object? state)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified action, state, and options.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="state">An object representing data to be used by the function.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to be assigned to the new task.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<object?, TResult> function, object? state, CancellationToken cancellationToken)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified action, state, and options.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="state">An object representing data to be used by the function.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to be assigned to the new task.</param>
	/// <param name="creationOptions">The <see cref="T:System.Threading.Tasks.TaskCreationOptions" /> used to customize the task's behavior.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="creationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskCreationOptions" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<object?, TResult> function, object? state, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified action, state, and options.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="state">An object representing data to be used by the function.</param>
	/// <param name="creationOptions">The <see cref="T:System.Threading.Tasks.TaskCreationOptions" /> used to customize the task's behavior.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="creationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskCreationOptions" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<object?, TResult> function, object? state, TaskCreationOptions creationOptions)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified function.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<TResult> function)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified function.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to be assigned to this task.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<TResult> function, CancellationToken cancellationToken)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified function and creation options.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new task.</param>
	/// <param name="creationOptions">The <see cref="T:System.Threading.Tasks.TaskCreationOptions" /> used to customize the task's behavior.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="creationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskCreationOptions" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
		: base(null)
	{
	}

	/// <summary>Initializes a new <see cref="T:System.Threading.Tasks.Task`1" /> with the specified function and creation options.</summary>
	/// <param name="function">The delegate that represents the code to execute in the task. When the function has completed, the task's <see cref="P:System.Threading.Tasks.Task`1.Result" /> property will be set to return the result value of the function.</param>
	/// <param name="creationOptions">The <see cref="T:System.Threading.Tasks.TaskCreationOptions" /> used to customize the task's behavior.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="creationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskCreationOptions" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">The <paramref name="function" /> argument is <see langword="null" />.</exception>
	public Task(Func<TResult> function, TaskCreationOptions creationOptions)
		: base(null)
	{
	}

	/// <summary>Configures an awaiter used to await this <see cref="T:System.Threading.Tasks.Task`1" />.</summary>
	/// <param name="continueOnCapturedContext">true to attempt to marshal the continuation back to the original context captured; otherwise, false.</param>
	/// <returns>An object used to await this task.</returns>
	public new ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext)
	{
		throw null;
	}

	/// <summary>Configures an awaiter used to await this <see cref="T:System.Threading.Tasks.Task" />.</summary>
	/// <param name="options">Options used to configure how awaits on this task are performed.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="options" /> argument specifies an invalid value.</exception>
	/// <returns>An object used to await this task.</returns>
	public new ConfiguredTaskAwaitable<TResult> ConfigureAwait(ConfigureAwaitOptions options)
	{
		throw null;
	}

	/// <summary>Creates a continuation that is passed state information and that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate is   passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation action.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>, object?> continuationAction, object? state)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be  passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation action.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new continuation task.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ObjectDisposedException">The provided <see cref="T:System.Threading.CancellationToken" /> has already been disposed.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>, object?> continuationAction, object? state, CancellationToken cancellationToken)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be  passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation action.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new continuation task.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as  well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its  execution.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <exception cref="T:System.ObjectDisposedException">The provided <see cref="T:System.Threading.CancellationToken" /> has already been disposed.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>, object?> continuationAction, object? state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be  passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation action.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such  as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>, object?> continuationAction, object? state, TaskContinuationOptions continuationOptions)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation action.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>, object?> continuationAction, object? state, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes asynchronously when the target task completes.</summary>
	/// <param name="continuationAction">An action to run when the antecedent <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task as an argument.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation task.</returns>
	public Task ContinueWith(Action<Task<TResult>> continuationAction)
	{
		throw null;
	}

	/// <summary>Creates a cancelable continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate is passed the completed task as an argument.</param>
	/// <param name="cancellationToken">The cancellation token that is passed to the new continuation task.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.  
	///
	///  -or-  
	///
	///  The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation task.</returns>
	public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes according the condition specified in <paramref name="continuationOptions" />.</summary>
	/// <param name="continuationAction">An action to run according the condition specified in <paramref name="continuationOptions" />. When run, the delegate will be passed the completed task as an argument.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new continuation task.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.  
	///
	///  -or-  
	///
	///  The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.  
	///
	///  -or-  
	///
	///  The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes according the condition specified in <paramref name="continuationOptions" />.</summary>
	/// <param name="continuationAction">An action to according the condition specified in <paramref name="continuationOptions" />. When run, the delegate will be passed the completed task as an argument.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskContinuationOptions continuationOptions)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task as an argument.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is <see langword="null" />.  
	///
	///  -or-  
	///
	///  The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task" />.</returns>
	public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation function.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object?, TNewResult> continuationFunction, object? state)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation function.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new task.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ObjectDisposedException">The provided <see cref="T:System.Threading.CancellationToken" /> has already been disposed.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object?, TNewResult> continuationFunction, object? state, CancellationToken cancellationToken)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be  passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation function.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new task.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The  <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <exception cref="T:System.ObjectDisposedException">The provided <see cref="T:System.Threading.CancellationToken" /> has already been disposed.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object?, TNewResult> continuationFunction, object? state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be  passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation function.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object?, TNewResult> continuationFunction, object? state, TaskContinuationOptions continuationOptions)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task and the caller-supplied state object as arguments.</param>
	/// <param name="state">An object representing data to be used by the continuation function.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object?, TNewResult> continuationFunction, object? state, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task as an argument.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task as an argument.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new task.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.  
	///
	///  -or-  
	///
	///  The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes according the condition specified in <paramref name="continuationOptions" />.</summary>
	/// <param name="continuationFunction">A function to run according the condition specified in <paramref name="continuationOptions" />.  
	///
	///  When run, the delegate will be passed as an argument this completed task.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that will be assigned to the new task.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.  
	///
	///  -or-  
	///
	///  The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.  
	///
	///  -or-  
	///
	///  The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes according the condition specified in <paramref name="continuationOptions" />.</summary>
	/// <param name="continuationFunction">A function to run according the condition specified in <paramref name="continuationOptions" />.  
	///
	///  When run, the delegate will be passed the completed task as an argument.</param>
	/// <param name="continuationOptions">Options for when the continuation is scheduled and how it behaves. This includes criteria, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled" />, as well as execution options, such as <see cref="F:System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously" />.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="continuationOptions" /> argument specifies an invalid value for <see cref="T:System.Threading.Tasks.TaskContinuationOptions" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions)
	{
		throw null;
	}

	/// <summary>Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1" /> completes.</summary>
	/// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1" /> completes. When run, the delegate will be passed the completed task as an argument.</param>
	/// <param name="scheduler">The <see cref="T:System.Threading.Tasks.TaskScheduler" /> to associate with the continuation task and to use for its execution.</param>
	/// <typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam>
	/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1" /> has been disposed.</exception>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction" /> argument is <see langword="null" />.  
	///
	///  -or-  
	///
	///  The <paramref name="scheduler" /> argument is <see langword="null" />.</exception>
	/// <returns>A new continuation <see cref="T:System.Threading.Tasks.Task`1" />.</returns>
	public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler)
	{
		throw null;
	}

	/// <summary>Gets an awaiter used to await this <see cref="T:System.Threading.Tasks.Task`1" />.</summary>
	/// <returns>An awaiter instance.</returns>
	public new TaskAwaiter<TResult> GetAwaiter()
	{
		throw null;
	}

	/// <summary>Gets a <see cref="T:System.Threading.Tasks.Task`1" /> that will complete when this <see cref="T:System.Threading.Tasks.Task`1" /> completes or when the specified <see cref="T:System.Threading.CancellationToken" /> has cancellation requested.</summary>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to monitor for a cancellation request.</param>
	/// <returns>The <see cref="T:System.Threading.Tasks.Task`1" /> representing the asynchronous wait. It may or may not be the same instance as the current instance.</returns>
	public new Task<TResult> WaitAsync(CancellationToken cancellationToken)
	{
		throw null;
	}

	/// <summary>Gets a <see cref="T:System.Threading.Tasks.Task`1" /> that will complete when this <see cref="T:System.Threading.Tasks.Task`1" /> completes or when the specified timeout expires.</summary>
	/// <param name="timeout">The timeout after which the <see cref="T:System.Threading.Tasks.Task" /> should be faulted with a <see cref="T:System.TimeoutException" /> if it hasn't otherwise completed.</param>
	/// <returns>The <see cref="T:System.Threading.Tasks.Task`1" /> representing the asynchronous wait. It may or may not be the same instance as the current instance.</returns>
	public new Task<TResult> WaitAsync(TimeSpan timeout)
	{
		throw null;
	}

	/// <summary>Gets a <see cref="T:System.Threading.Tasks.Task`1" /> that will complete when this <see cref="T:System.Threading.Tasks.Task`1" /> completes, when the specified timeout expires, or when the specified <see cref="T:System.Threading.CancellationToken" /> has cancellation requested.</summary>
	/// <param name="timeout">The timeout after which the <see cref="T:System.Threading.Tasks.Task" /> should be faulted with a <see cref="T:System.TimeoutException" /> if it hasn't otherwise completed.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to monitor for a cancellation request.</param>
	/// <returns>The <see cref="T:System.Threading.Tasks.Task`1" /> representing the asynchronous wait. It may or may not be the same instance as the current instance.</returns>
	public new Task<TResult> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
	{
		throw null;
	}

	/// <summary>Gets a <see cref="T:System.Threading.Tasks.Task`1" /> that will complete when this <see cref="T:System.Threading.Tasks.Task`1" /> completes or when the specified timeout expires.</summary>
	/// <param name="timeout">The timeout after which the <see cref="T:System.Threading.Tasks.Task" /> should be faulted with a <see cref="T:System.TimeoutException" /> if it hasn't otherwise completed.</param>
	/// <param name="timeProvider">The <see cref="T:System.TimeProvider" /> with which to interpret <paramref name="timeout" />.</param>
	/// <returns>The <see cref="T:System.Threading.Tasks.Task`1" /> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
	public new Task<TResult> WaitAsync(TimeSpan timeout, TimeProvider timeProvider)
	{
		throw null;
	}

	/// <summary>Gets a <see cref="T:System.Threading.Tasks.Task`1" /> that will complete when this <see cref="T:System.Threading.Tasks.Task`1" /> completes, when the specified timeout expires, or when the specified <see cref="T:System.Threading.CancellationToken" /> has cancellation requested.</summary>
	/// <param name="timeout">The timeout after which the <see cref="T:System.Threading.Tasks.Task" /> should be faulted with a <see cref="T:System.TimeoutException" /> if it hasn't otherwise completed.</param>
	/// <param name="timeProvider">The <see cref="T:System.TimeProvider" /> with which to interpret <paramref name="timeout" />.</param>
	/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to monitor for a cancellation request.</param>
	/// <returns>The <see cref="T:System.Threading.Tasks.Task`1" /> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
	public new Task<TResult> WaitAsync(TimeSpan timeout, TimeProvider timeProvider, CancellationToken cancellationToken)
	{
		throw null;
	}
}
